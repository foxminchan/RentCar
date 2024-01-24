resource "jobs" "rent_car_api" {
  jobspec = file("${path.module}/jobs/api.nomad.hcl")
}
