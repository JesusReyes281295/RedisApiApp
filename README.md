# RedisApiApp 🚀

## Description 📖
RedisApiApp is a web application developed in .NET 9 using C# 12. This project demonstrates how to create and use two endpoints that allow you to add and retrieve user information using Redis as the database. The main goal is to provide an easy-to-understand example of integrating Redis into a .NET 9 application.

## Features ✨
- **Add User Endpoint**: Easily add user information to the database. 👤  
- **Retrieve User Endpoint**: Retrieve user information with a simple request. 📄  
- **Incremental ID Definition**: Each user is automatically assigned a unique, incremental ID. 🔢  

## Objective 🎯
This repository aims to help developers understand the basic usage of Redis in a .NET 9 application. It serves as an educational resource for those looking to learn how to integrate Redis with modern .NET technologies.

## Setup & Installation 🔧

### Prerequisites 📌
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
- [Redis](https://redis.io/)

### Redis Installation
- **Windows Users:** Redis is installed on a Linux subsystem.  
- **macOS/Linux Users:** Install Redis directly on your system—no subsystem is required.

### Steps to Run the Project 🏃‍♂️
1. **Clone the repository:**
   ```bash
   git clone https://github.com/JesusReyes281295/RedisApiApp.git
   cd RedisApiApp
   ```
2. **Build the project:**
   ```bash
   dotnet build
   ```
3. **Run the application:**
   ```bash
   dotnet run
   ```

## Usage 🚀

### Add User
To add a user, send a **POST** request to the `/addUser` endpoint with the user information in JSON format. For example:
```json
{
  "name": "John Doe",
  "email": "john.doe@example.com"
}
```

### Retrieve User
To retrieve user information, send a **GET** request to the `/getUser` endpoint with the user ID as a query parameter. For example:
```
/getUser?id=1
```

## Project Structure 📁
- **Controllers:** Contains the API endpoints.  
- **Models:** Defines the user model and related data structures.  
- **Services:** Contains business logic including Redis integration.  
- **Program.cs:** Configures and runs the application.

## Contributing 🤝
Contributions are welcome! If you have suggestions, improvements, or bug fixes, please open an issue or submit a pull request. Let's work together to improve this project!

## License 📜
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---

Happy coding! 😄
