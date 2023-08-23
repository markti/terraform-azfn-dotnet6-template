output "resource_group_name" {
  value = azurerm_resource_group.main.name
}
output "function_name" {
  value = azurerm_linux_function_app.foo.name
}