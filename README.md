[![Selenium Tests](https://github.com/KarlTaylor908/selenium-ui-tests/actions/workflows/tests.yml/badge.svg?branch=SeleniumTests)](https://github.com/KarlTaylor908/selenium-ui-tests/actions/workflows/tests.yml)
# Selenium UI Tests
- This project contains automated UI Tests using Selenium Web Driver and NUnit for a demo web application. 

## Features:
- Browser-based automated testing using Selenium WebDriver with C#
- Test execution with NUnit
- Easy-to-extend test framework
- Page Object Model (POM)
- Parallel tests
- GitHub Actions (CI)

Target site: **https://the-internet.herokuapp.com/**

## Tests:
- ✅ Add/Remove Elements  
- ✅ Broken Images (detect bad HTTP responses)  
- ✅ Challenging DOM interactions  
- ✅ Checkboxes (toggle & assert state)  
- ✅ Context Menu (right-click + alert)  
- ✅ Home page shown

## Project structure
- pages/ # Page Object Model structure (POM)
- tests/ # UI tests (.cs)
- utilities/ # Test setup

## Test Examples:
Extent Report with a failed test:
<img width="1074" height="593" alt="image" src="https://github.com/user-attachments/assets/a9f96393-e8e0-4caf-a6e6-daefc32e187c" />

Screenshot taken on failure:
<img width="1022" height="679" alt="image" src="https://github.com/user-attachments/assets/a0af547b-d98d-40fc-b025-5ed8f9ce74bf" />

Dashboards of tests passing:
<img width="1656" height="430" alt="image" src="https://github.com/user-attachments/assets/ae1f8efb-4ac0-4e1e-83b7-1fd5e5ed497f" />


## Instructions on Use
### 1) Prerequisite
- .NET 8 SDK
- A browser and matching web driver

### 2) Run Tests
- dotnet restore
- dotnet build --configuration Release

### 3) Run Tests
- Run tests in Visual Studio or use


