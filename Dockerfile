FROM mcr.microsoft.com/dotnet/sdk:6.0 As build-dev
WORKDIR /app
EXPOSE  80
EXPOSE 443
 
COPY *.sln ./
COPY . ./
RUN dotnet restore 

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0 As final-dev
WORKDIR /app
COPY --from=build-dev /app/out .
ENTRYPOINT [ "dotnet" ,"ExpenseTracker.dll"]