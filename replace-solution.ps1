#!/bin/pwsh

param(
    [string]$StudentSolutionFile = "data/solutions.txt",
    [string]$ProjectFilePath = "TestProject/Distance.cs"
)

Write-Host "Replacing solution in: $ProjectFilePath"
Write-Host "Using student solution from: $StudentSolutionFile"

# Проверяем файлы
if (-not (Test-Path $StudentSolutionFile)) {
    Write-Error "Student solution file not found: $StudentSolutionFile"
    exit 1
}

if (-not (Test-Path $ProjectFilePath)) {
    Write-Error "Project file not found: $ProjectFilePath"
    exit 1
}

# Читаем решение студента
$studentCode = Get-Content $StudentSolutionFile -Raw
Write-Host "Read student solution ($($studentCode.Length) characters)"

# Проверяем, что решение содержит нужный класс и метод
if ($studentCode -notmatch "class Distance" -or $studentCode -notmatch "GetDistance") {
    Write-Warning "Student solution may not contain required class/method"
}

# Создаем backup оригинального файла
$backupFile = "$ProjectFilePath.backup"
Copy-Item -Path $ProjectFilePath -Destination $backupFile -Force
Write-Host "Created backup: $backupFile"

# Заменяем содержимое файла
try {
    Set-Content -Path $ProjectFilePath -Value $studentCode -ErrorAction Stop
    Write-Host "Successfully replaced solution in: $ProjectFilePath"
    
    # Проверяем результат
    $newContent = Get-Content $ProjectFilePath -Raw
    Write-Host "New file size: $($newContent.Length) characters"
}
catch {
    Write-Error "Failed to replace solution: $_"
    # Восстанавливаем backup при ошибке
    Copy-Item -Path $backupFile -Destination $ProjectFilePath -Force
    Write-Host "Restored original file from backup"
    exit 1
}
