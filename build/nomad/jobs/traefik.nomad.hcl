job "traefik" {
  datacenters = ["dc1"]
  type        = "system"

  group "traefik" {
    network {
      port "http" {
        static = 80
      }

      port "https" {
        static = 443
      }
    }
  }

  service {
    name = "traefik"
    port = "http"

    check {
      type     = "http"
      path     = "/ping"
      port     = "http"
      interval = "10s"
      timeout  = "2s"
    }
  }

  task "traefik" {
    driver = "docker"

    config {
      image        = "traefik:v3.0.0"
      port         = ["http", "https"]
      network_mode = "host"
      volumes      = ["local/traefik.yaml:/etc/traefik/traefik.yaml"]
    }

    template {
      data        = <<EOF
log:
	level: INFO
	traefikLogsFile: "/var/log/traefik/traefik.log"
accessLog:
	filePath: "/var/log/traefik/access.log"
format: "json"
api:
	insecure: true
	dashboard: true
ping:
	entryPoint: http
serversTransport:
	insecureSkipVerify: true
providers:
	consulCatalog:
		endpoint: "consul.service.consul:8500"
		prefix: "traefik"
		refreshInterval: "10s"
		exposedByDefault: false
		endpoint:
			address: "consul.service.consul:8500"
			scheme: "http"
			tls:
				insecureSkipVerify: true
		connectAware: true
EOF
      destination = "local/traefik.yaml"
    }

    resources {
      cpu    = 500
      memory = 256
    }
  }
}
