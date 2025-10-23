param(
    [string]$StudentSolutionFile = "data/solutions.txt",
    [string]$ProjectFilePath = "TestProject/Distance.cs"
)

Write-Host "=== Replacing Student Solution ==="
Write-Host "Source: $StudentSolutionFile"
Write-Host "Target: $ProjectFilePath"

# Проверяем существование файлов
if (-not (Test-Path $StudentSolutionFile)) {
    Write-Error "❌ Student solution file not found: $StudentSolutionFile"
    Write-Host "Available files in data/:"
    if (Test-Path "data") {
        Get-ChildItem "data" -File
    }
    exit 1
}

if (-not (Test-Path $ProjectFilePath)) {
    Write-Error "❌ Project file not found: $ProjectFilePath"
    Write-Host "Available files in TestProject/:"
    if (Test-Path "TestProject") {
        Get-ChildItem "TestProject" -File
    }
    exit 1
}

# Читаем решение студента
Write-Host "Reading student solution..."
$studentCode = Get-Content $StudentSolutionFile -Raw -Encoding UTF8
Write-Host "✓ Read student solution ($($studentCode.Length) characters)"

# Создаем backup оригинального файла
$backupFile = "$ProjectFilePath.backup"
try {
    Copy-Item -Path $ProjectFilePath -Destination $backupFile -Force
    Write-Host "✓ Created backup: $backupFile"
}
catch {
    Write-Error "❌ Failed to create backup: $_"
    exit 1
}

# Заменяем содержимое файла
try {
    Write-Host "Replacing solution in project..."
    Set-Content -Path $ProjectFilePath -Value $studentCode -Encoding UTF8 -Force
    Write-Host "✓ Successfully replaced solution"
    
    # Проверяем результат
    $newContent = Get-Content $ProjectFilePath -Raw -Encoding UTF8
    Write-Host "✓ New file size: $($newContent.Length) characters"
    
    # Показываем первые несколько строк для проверки
    $preview = ($newContent -split "`n")[0..4] -join "`n"
    Write-Host "Preview of new content:"
    Write-Host $preview
}
catch {
    Write-Error "❌ Failed to replace solution: $_"
    # Восстанавливаем backup при ошибке
    try {
        Copy-Item -Path $backupFile -Destination $ProjectFilePath -Force
        Write-Host "✓ Restored original file from backup"
    }
    catch {
        Write-Error "❌ Failed to restore backup: $_"
    }
    exit 1
}

Write-Host "=== Solution Replacement Complete ==="
