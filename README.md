# Rent Car

![License](https://img.shields.io/github/license/foxminchan/RentCar?label=License)

## Description

<p align="justify">
The "RentCar" repository is a software project dedicated to facilitating car rental operations. It encompasses features like user interfaces for customers to reserve vehicles, administrative tools for fleet management, reservation handling, vehicle availability tracking, and potentially payment processing integration. The repository aims to optimize the processes associated with renting and managing a fleet of cars.
</p>

## Prerequisites

- [Node.js](https://nodejs.org/en/)
- [pnpm](https://pnpm.io/)
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Nomad](https://www.nomadproject.io/)
- [Consul](https://www.consul.io/)
- [Vault](https://www.vaultproject.io/)
- [Nuke](https://nuke.build/)

## Installation and Setup

Clone the repository:

```bash
git clone https://github.com/foxminchan/RentCar.git
```

Install necessary tools:

```bash
pnpm install

dotnet tool install dotnet-ef -g
dotnet tool install Nuke.GlobalTool --global
```

## Running the Application

<p align="justify">
To run the application, you need to start the Nomad and Consul servers. You can do this by running the following command:
</p>

```bash
dotnet watch -p ./src/RentCar.Usecase/ run -lp https
```

## OpenTelemetry

RentCar uses [OpenTelemetry](https://opentelemetry.io/) to collect logs, metrics, and traces. The following are the services that are currently supported:

You can view the metrics and traces by running the following command:

```bash
docker-compose ./docker/docker-compose.o11y.yml up
```

> For sebp/elk, you need to run the following command to increase the virtual memory:
>
> ```bash
> sudo sysctl -w vm.max_map_count=262144
> ```

## Start HashiCorp Stack

<p align="justify">
To start the HashiCorp stack, you need to start the Nomad, Consul, and Vault servers. You can do this by running the following command:
</p>

```bash
cd build/local
./start.sh
```

<p align="justify">
To use Terraform to provisioning the API, you need to run the following command:
</p>

```bash
cd build/nomad
terraform init
terraform apply
```

<p align="justify">
For clean up, you need to run the following command:
</p>

```bash
cd build/nomad
terraform destroy
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
