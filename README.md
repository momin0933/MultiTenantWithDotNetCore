# MultiTenantWithDotNetCore
Multi-tenant support for ASP.NET Core 8

This is a demo project created for my Multi-Tenant ASP.NET Core presentation. It showcases the multi-tenant solutions I have developed for ASP.NET Core. I also use this demo for presentations to illustrate these concepts in action.

The solutions provided here are not definitive; in certain cases, alternative approaches may be more suitable. However, the code in this project serves as an excellent starting point for implementing multi-tenant architectures.

Features
The demo application demonstrates a variety of features and solutions, including:<br>

  <b>Database Per Tenant Strategy:</b> Managing a separate database for each tenant.<br>
  <b>Shared Database for Tenants:</b> Implementing a shared database model for multiple tenants.<br>
  <b>Multi-Tenant EF Core Database Context with Security:</b> Ensuring tenant data isolation and security within a shared EF Core context.<br>
  <b>Dynamic Tenant Configuration Loading:</b> Loading tenant-specific configurations at runtime.<br>
  <b>Missing Tenant Middleware:</b> Middleware to handle scenarios where tenant information is missing or invalid.<br>
  <b>Tenant Provider:</b> A mechanism to retrieve the current tenant's details in a structured way.<br>
  <b>Tenant-Based Dependency Injection:</b> Configuring services and dependencies per tenant.<br>
  <b>Unit Testing for Multi-Tenant Database Context:</b> A forthcoming feature to facilitate reliable testing for tenant-aware database contexts.<br>
  <b>Multi-Tenant Configurable Composite Commands:</b> Enabling tenant-specific command execution configurations.<br>
  
Additionally, I plan to include a video tutorial to provide a more in-depth walkthrough of this project in the future. Stay tuned!
