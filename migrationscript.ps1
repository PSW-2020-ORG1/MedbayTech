# NOTE(Jovan): How to use:
# Create microservices.txt (view microservicesexample.txt)
# Run this script and enjoy


# NOTE(Jovan): Read locations from microservices.txt
$stream_reader = New-Object System.IO.StreamReader{microservices.txt}
$line_number = 1
while(($current_line = $stream_reader.ReadLine()) -ne $null)
{
    # NOTE(Jovan): For each location
    # Go in
    # Remove Migrations folder if it exists
    # Add new migration0
    # Update database
    # Exit folder
    
    Push-Location $current_line
    rm -r -fo Migrations
    dotnet ef migrations add migration0
    dotnet ef database update
    Pop-Location

    $line_number++
}
# NOTE(Jovan): Optional 'hold' prompt, comment out for auto close
Read-Host -Prompt "Press Enter to exit"
