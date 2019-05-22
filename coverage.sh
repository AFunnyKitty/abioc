#!/bin/bash -eu

# function to display commands
exe() { echo; echo "\$ $*" ; "$@" ; }

# Parameters
framework="${1-netcoreapp2.1}"
config="${2-Debug}"

testResults="test/TestResults"

# Cannot use a bash solution in alpine builds https://stackoverflow.com/a/246128
#rootDir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
rootDir=$(pwd)

testProj1="$rootDir/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj"
testProj2="$rootDir/test/Abioc.Tests/Abioc.Tests.csproj"

SECONDS=0

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

# Restore the packages
exe dotnet restore "$rootDir"

# Build the test projects

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

exe dotnet build --no-restore -f "$framework" -c "$config" "$testProj1"

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

exe dotnet build --no-restore -f "$framework" -c "$config" "$testProj2"

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

# Execute the tests
exe dotnet test --no-restore --no-build -f "$framework" -c "$config" \
"$testProj1" \
--results-directory "$rootDir/$testResults/output/" \
--logger "\"trx;LogFileName=$(basename "$testProj1" .csproj).trx\""

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

exe dotnet test --no-restore --no-build -f "$framework" -c "$config" \
"$testProj2" \
--results-directory "$rootDir/$testResults/output/" \
--logger "\"trx;LogFileName=$(basename "$testProj2" .csproj).trx\""

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

# Install trx2junit if not already installed
if [ ! -f "$rootDir/$testResults/tools/trx2junit" ]
then
   exe dotnet tool install trx2junit --tool-path "$rootDir/$testResults/tools"
fi

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."

# Convert the MSTest trx files to junit xml
exe "$rootDir/$testResults/tools/trx2junit" "$rootDir/$testResults/output"/*.trx

duration="$SECONDS"
echo
date
echo "$((duration / 60)) minutes and $((duration % 60)) seconds elapsed."
