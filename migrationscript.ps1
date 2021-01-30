# NOTE(Jovan): How to use:
# If not already, install ef tools by running this in powershell:
#    dotnet tool install --global dotnet-ef
# Create microservices.txt (view microservicesexample.txt)
# Run this script and enjoy


# NOTE(Jovan): Read locations from microservices.txt
$stream_reader = New-Object System.IO.StreamReader{C:\MedbayTech\microservices.txt}
$line_number = 1
while(($current_line = $stream_reader.ReadLine()) -ne $null)
{
    # NOTE(Jovan): For each location
    # Go in
    # Remove Migrations folder if it exists
    # Add new migration0s
    # Update database
    # Exit folder
    
    Push-Location $current_line
    if(Test-Path Migrations) {
        rm -r -fo Migrations
    }
    dotnet ef migrations add migration0
    dotnet ef database update
    Pop-Location

    $line_number++
}
# NOTE(Jovan): Optional 'hold' prompt, comment out for auto close
Read-Host -Prompt "Press Enter to exit"
