job "rent-car-api" {
  datacenters = ["dc1"]

  group "rent-car-api" {
    count = 1

    network {
      mode = "bridge"
      port "http" {
        to = 8080
      }
    }

    service {
      name = "rent-car-api"
      tags = ["api"]
      port = 8080
      check {
        name     = "alive"
        type     = "http"
        protocol = "http"
        path     = "/health"
        interval = "10s"
        timeout  = "2s"
      }
    }

    task "rent-car-api" {
      driver = "docker"

      config {
        image = "ghcr.io/foxminchan/rent-car-api:latest"
        port  = 8080
      }

      env {
        ASPNETCORE_ENVIRONMENT = "Development"
      }

      resources {
        cpu    = 500
        memory = 256
        network {
          mbits = 10
          port "http" {
            static = 8080
          }
        }
      }
    }
  }
}