# ClientesApi - API REST de Administración de Clientes

Proyecto de Programación II - .NET 10 + Entity Framework Core + MySQL

## Pasos para correrlo

1. **Descomprime** el archivo y abre la carpeta `ClientesApi` en Visual Studio 2026 (o `dotnet` desde consola).

2. **Verifica la base de datos** en MySQL Workbench:
   - Crea una base de datos vacía llamada `clientes_db` (o el nombre que prefieras):
     ```sql
     CREATE DATABASE clientes_db;
     ```

3. **Revisa la cadena de conexión** en `appsettings.json` si tu usuario/puerto es distinto:
   ```
   Server=localhost;Port=3306;Database=clientes_db;User=root;Password=Manuel1234!;
   ```
   Si tu usuario de MySQL no es `root`, cámbialo.

4. **Restaura los paquetes NuGet** (Visual Studio lo hace solo al abrir, o desde consola):
   ```
   dotnet restore
   ```

5. **Instala la herramienta de EF Core** (solo una vez en tu máquina, si no la tienes):
   ```
   dotnet tool install --global dotnet-ef
   ```

6. **Crea la migración inicial** (esto genera las tablas a partir del modelo `Cliente`):
   ```
   dotnet ef migrations add InicialClientes
   ```

7. **Aplica la migración** a la base de datos (esto crea la tabla `Clientes` en MySQL):
   ```
   dotnet ef database update
   ```

8. **Corre el proyecto**:
   ```
   dotnet run
   ```
   O presiona F5 en Visual Studio.

9. Se abrirá **Swagger** automáticamente (`/swagger`), donde puedes probar los 5 endpoints:
   - `GET /api/clientes`
   - `GET /api/clientes/{id}`
   - `POST /api/clientes`
   - `PUT /api/clientes/{id}`
   - `DELETE /api/clientes/{id}`

10. Sube el proyecto a un repositorio de **GitHub** y entrega el link (recuerda no subir contraseñas reales si el repo es público — puedes cambiar la contraseña en `appsettings.json` antes de subirlo, o usar un `appsettings.Development.json` que agregues al `.gitignore`).

## Estructura del proyecto

```
ClientesApi/
├── Controllers/
│   └── ClientesController.cs   (CRUD completo)
├── Data/
│   └── ClientesDbContext.cs    (DbContext de EF Core)
├── Models/
│   └── Cliente.cs              (Modelo con los 8 campos pedidos)
├── Properties/
│   └── launchSettings.json
├── Program.cs                  (Configuración y conexión a MySQL)
├── appsettings.json            (Cadena de conexión)
└── ClientesApi.csproj
```
