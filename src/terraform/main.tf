resource "azurerm_resource_group" "main" {
  name     = "rg-${var.application_name}-${var.environment_name}"
  location = var.location
}
resource "random_string" "name" {
  length  = 8
  special = false
  upper   = false
}
data "azurerm_client_config" "current" {}