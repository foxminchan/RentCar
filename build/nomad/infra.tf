provider "nomad" {
  address = "http://localhost:4646"
}
resource "jobs" "postgres_db" {
  jobspec    = file("${path.module}/jobs/postgresdb.nomad.hcl")
  depends_on = [jobs.traefik]
}
resource "jobs" "traefik" {
  jobspec    = file("${path.module}/jobs/traefik.nomad.hcl")
  depends_on = [jobs.traefik]
}
