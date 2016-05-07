#!/bin/sh
cmd="$1"
if [ "$cmd" = "d" ]; then
    xbuild Hanselman.iOS/Hanselman.iOS.csproj /t:_DetectSigningIdentity /v:diag
else
    xbuild Hanselman.iOS/Hanselman.iOS.csproj /t:build /v:diag
fi