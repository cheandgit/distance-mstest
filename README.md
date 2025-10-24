# distance-mstest
## Структура проекта 
```
.github/
└── workflows/
    └── test-runner.yml - GitHub Actions workflow
data/
└── solutions.txt - Файл с решением
replace-solution.ps1 - PowerShell скрипт (читает решение студента и заменяет содержимое файла Distance.cs)
TestProject/ - Папка проекта с тестами
├── TestProject.csproj
├── Program.cs
├── Tests.cs
└── Distance.cs
```
