name: Test Student Solutions

on:
  push:
    branches: [ main, master ]
  pull_request:
    branches: [ main, master ]
  workflow_dispatch:

jobs:
  test-solutions:
    runs-on: windows-latest
    
    steps:
    - name: Checkout repository
      uses: actions/checkout@v4
      
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '6.0.x'
        
    - name: Validate structure
      run: |
        echo "Repository structure:"
        Get-ChildItem -Recurse
        echo "Student solution exists: $(Test-Path data/solutions.txt)"
        
    - name: Replace student solution
      run: |
        .\replace-solution.ps1 -StudentSolutionFile "data/solutions.txt" -ProjectFilePath "TestProject/Distance.cs"
        
    - name: Restore dependencies
      run: dotnet restore TestProject/TestProject.csproj
      
    - name: Build project
      run: dotnet build TestProject/TestProject.csproj --configuration Release --no-restore
      
    - name: Run tests
      run: dotnet test TestProject/TestProject.csproj --configuration Release --no-build --verbosity normal --logger "trx;LogFileName=test-results.trx"
      
    - name: Restore original solution
      if: always()
      run: |
        if (Test-Path "TestProject/Distance.cs.backup") {
            Copy-Item -Path "TestProject/Distance.cs.backup" -Destination "TestProject/Distance.cs" -Force
            Remove-Item "TestProject/Distance.cs.backup"
            Write-Host "Restored original Distance.cs"
        }
        
    - name: Upload test results
      uses: actions/upload-artifact@v3
      if: always()
      with:
        name: test-results
        path: TestProject/TestResults/*.trx
        retention-days: 30
