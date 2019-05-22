########################################################################################################################
# .NET Core 2.1.604
FROM mcr.microsoft.com/dotnet/core/sdk:2.1.604

ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

WORKDIR /work

# Copy just the solution and proj files to make best use of docker image caching
COPY ./abioc.sln .
COPY ./src/Abioc/Abioc.csproj ./src/Abioc/Abioc.csproj
COPY ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
COPY ./test/Abioc.Tests/Abioc.Tests.csproj ./test/Abioc.Tests/Abioc.Tests.csproj

# Run restore on just the project files, this should cache the image after restore.
RUN dotnet restore

COPY . .

RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj

ARG CACHE_BUST="0"

RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.Internal.trx"
RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.trx"

########################################################################################################################
# .NET Core 2.2.204
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.204

ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

WORKDIR /work

# Copy just the solution and proj files to make best use of docker image caching
COPY ./abioc.sln .
COPY ./src/Abioc/Abioc.csproj ./src/Abioc/Abioc.csproj
COPY ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
COPY ./test/Abioc.Tests/Abioc.Tests.csproj ./test/Abioc.Tests/Abioc.Tests.csproj

# Run restore on just the project files, this should cache the image after restore.
RUN dotnet restore

COPY . .

RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj

ARG CACHE_BUST="0"

RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.Internal.trx"
RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.trx"

########################################################################################################################
# .NET Core 2.1.700
FROM mcr.microsoft.com/dotnet/core/sdk:2.1.700

ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

WORKDIR /work

# Copy just the solution and proj files to make best use of docker image caching
COPY ./abioc.sln .
COPY ./src/Abioc/Abioc.csproj ./src/Abioc/Abioc.csproj
COPY ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
COPY ./test/Abioc.Tests/Abioc.Tests.csproj ./test/Abioc.Tests/Abioc.Tests.csproj

# Run restore on just the project files, this should cache the image after restore.
RUN dotnet restore

COPY . .

RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj

ARG CACHE_BUST="0"

RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.Internal.trx"
RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.trx"

########################################################################################################################
# .NET Core 2.2.300
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.300

ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

WORKDIR /work

# Copy just the solution and proj files to make best use of docker image caching
COPY ./abioc.sln .
COPY ./src/Abioc/Abioc.csproj ./src/Abioc/Abioc.csproj
COPY ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj ./test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
COPY ./test/Abioc.Tests/Abioc.Tests.csproj ./test/Abioc.Tests/Abioc.Tests.csproj

# Run restore on just the project files, this should cache the image after restore.
RUN dotnet restore

COPY . .

RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj
RUN dotnet build --no-restore -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj

ARG CACHE_BUST="0"

RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests.Internal/Abioc.Tests.Internal.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.Internal.trx"
RUN dotnet test --no-restore --no-build -f netcoreapp2.1 -c Release /work/test/Abioc.Tests/Abioc.Tests.csproj --results-directory /work/test/TestResults/output/ --logger "trx;LogFileName=Abioc.Tests.trx"
