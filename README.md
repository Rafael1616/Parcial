La base que utilize se llama "Northwind" teniendo como referencia la tabla Proveedores, la cual tiene una restriccion en la llave primaria que la toma como foranea en la tabla "Products", para continuar hay que desabilitarla siguiendo el siguiente comando en la base de datos: ALTER TABLE Products
NOCHECK CONSTRAINT FK_Products_suppliers;
