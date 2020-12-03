param([string] $ip)

#save current envvar state
$tmp = $Env:DOTNET_URLS

if ($ip){
    $address
    if ($ip.StartsWith("http")){
        $address = $ip
    }else{
        $address = "http://" + $ip
    }
    Write-Host "Using address" $address
    $Env:DOTNET_URLS = "$address"
} else {
    Write-Host "Using default ip address"
}

try {
    dotnet watch run --configuration Debug --launch-profile WebServer -- "WebServer(~D:\\Antilatency.com.WebServer~);"
} finally {
    #restore envvar state
    if (!$tmp){
        Remove-Item Env:DOTNET_URLS
    }else{
        $Env:DOTNET_URLS = $tmp
    }
}
