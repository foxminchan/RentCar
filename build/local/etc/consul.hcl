node_name = "consul"
server    = true
bootstrap = true

ui_config {
  enabled = true
}

datacenter = "dc1"
log_level  = "INFO"

address {
  http = "0.0.0.0"
}

connect {
  enabled = true
}

ports {
  grpc = 8502
}