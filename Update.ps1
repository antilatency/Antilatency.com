$realUpstreamUrl = "https://github.com/antilatency/Antilatency.com.git"

pushd $PSScriptRoot

$originUrl = git remote get-url origin
if($LastExitCode -ne 0){
    Write-Host "Failed to get origin URL"
    exit 1
}

git pull
git submodule update --init --recursive
git submodule foreach -q --recursive 'git checkout $(git config -f $toplevel/.gitmodules submodule.$name.branch || echo master) && git pull'

if($originUrl -ne $realUpstreamUrl){
    Write-Host "This is fork repo!"
    $upstreamUrl = git remote get-url upstream
    if(($LastExitCode -ne 0) -or ($upstreamUrl -ne $realUpstreamUrl)){
        Write-Host "Setting upstream URL"
        git remote add upstream $realUpstreamUrl
    }

    git pull upstream master
}

popd
