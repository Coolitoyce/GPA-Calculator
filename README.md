# GPA Calculator Program

## 📌 Overview

A simple **C# console application** that allows students to calculate their **Grade Point Average (GPA)** based on subject percentages and credit hours. This tool is designed to be lightweight, easy to use, and efficient for quick GPA computations.

## ⚡ Features

- 📊 **Accurate GPA Calculation** based on percentage and credit hours.
- 🎨 **Formatted Output** with aligned columns and colors.
- ⏳ **Typewriter Effect** (delayed printing for better readability) just for fun.
- 🏆 **User-Friendly** and simple command-line interface.

## 🎯 Usage

1. Run the application.
2. Enter the total number of subjects.
3. Enter the **name**, **percentage**, and **credit hours** for each subject when prompted.
4. The program will compute and display your **GPA**.

## 🖼️ Example Output

![Example output screenshot](https://i.imgur.com/IQMzkUp.png)

## 🛠️ Installation

### **1. Prerequisites**

- Install **.NET SDK** (if not already installed): [Download .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet)
- Works on **Windows, Linux, or macOS** (supports any OS with .NET runtime).

### **2. Clone the Repository**

```sh
git clone https://github.com/coolitoyce/GPA-Calculator.git
cd GPA-Calculator
```

### **3. Build the Project**

```sh
dotnet build
```

### **4. Run the Program**

```sh
dotnet run
```

## ⚠️ Note

- Your university may be using a different GPA calculation method.  
  If needed, modify the logic inside:
  - `GetPoints()` method in `GPA_Calculator.cs`.
