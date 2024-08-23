
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



