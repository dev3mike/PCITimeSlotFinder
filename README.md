# PCI Stand-up Scheduler

## Overview
this tool optimizes daily stand-up scheduling for teams using a .NET API, adhering to clean architecture principles. It identifies potential 15-minute intervals for meetings, ensuring the required number of team members are available, based on schedules fetched from a REST API.

## Features
- **Flexible Scheduling**: Calculates suitable 15-minute meeting intervals.
- **Customizable Team Requirements**: Adjusts to the number of attendees specified by team leaders.
- **REST API Integration**: Parses json objects from a REST API for daily schedules.

## Tech Stack
- **.NET**: For building a robust and scalable API.
- **Clean Architecture**: Ensures maintainability and separation of concerns.
- **Swagger**: For comprehensive API documentation and testing.

## Getting Started
1. **Clone the repository** and ensure .NET is installed on your machine.
2. **Run the API project**: The application starts, and the Swagger documentation is automatically opened at `http://localhost:5291/swagger`. This provides a detailed overview of available endpoints and usage.
3. **Use the Tool**: Through the Swagger UI, you can input the required number of team members and get the suitable time slots for meetings.
