
# Despachos Monorep

**Backend**

Se compone de varios microservicios los cuales exponen los endpoints que integran
el API REST de Despachos. Cada microservicio abarca un subconjunto concreto de
funcionalidades estrechamente relacionadas como se indica a continuación:

* **Management.** Expone los servicios para la gestión o administración general del despacho:
    * Clientes
    * Ejecutivos 
    * Regímenes
    * Obligaciones
    * Días no laborales
    * o Etc.

* **Data Fetching.** Expone los servicios para obtener la información de la constancia de situación fiscal y opinión del cumplimiento de los clientes.

* **Obligations.** Servicios para el seguimiento y consultas relacionadas con obligaciones.

* **Sync**. Expondrá los servicios que permitirán la comunicación e intercambio de información entre Despachos y las aplicaciones de escritorio Contabilidad y Bancos

## Enfoque de Desarrllo Api Managment

El microservicio Management ha sido desarrollado utilizando las siguientes estrategias y enfoques arquitectónicos:

- **Clean Architecture:** Se asegura que la estructura del código sea limpia, modular y fácil de mantener. (Onion Architecture)
- **Domain-Driven Design (DDD):** Enfocado en la modelación de la lógica de negocio del dominio, promoviendo la separación de preocupaciones y una mejor organización del código.


### Herramientas y Tecnologías Utilizadas

- **Nx:** Monorepo tool que permite gestionar eficientemente los microservicios y sus dependencias.
- **nxdotnetcore:** Plugin de Nx para integrar proyectos .NET en el monorepo.
- **.NET 8:** version de .net.
- **Entity Framework Core:** ORM para manejo de bases de datos relacionales.
- **PostgreSQL:** Base de datos relacional utilizada en los microservicios.
- **Swagger:** Para la documentación automática de los endpoints API.
- **MediatR:** Implementación del patrón CQRS para una mayor separación de la lógica de consultas y comandos.
- **AutoMapper:** Mapeo de entidades de dominio a DTOs y viceversa.
- **xUnit:** Framework de pruebas unitarias.
- **Docker:** Contenedorización de los microservicios para un despliegue eficiente.
- **FluentValidation:** Contenedorización de los microservicios para un despliegue eficiente.
- 

## Instalación

Instalar con npm


