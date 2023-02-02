#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Simple_Ecommers_App.Api/Simple_Ecommers_App.Api.csproj", "Simple_Ecommers_App.Api/"]
COPY ["Simple_Ecommers_App.Application/Simple_Ecommers_App.Application.csproj", "Simple_Ecommers_App.Application/"]
COPY ["Simple_Ecommers_App.Domain/Simple_Ecommers_App.Domain.csproj", "Simple_Ecommers_App.Domain/"]
COPY ["Simple_Ecommers_App.Infrastructure/Simple_Ecommers_App.Infrastructure.csproj", "Simple_Ecommers_App.Infrastructure/"]
RUN dotnet restore "Simple_Ecommers_App.Api/Simple_Ecommers_App.Api.csproj"
COPY . .
WORKDIR "/src/Simple_Ecommers_App.Api"
RUN dotnet build "Simple_Ecommers_App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Simple_Ecommers_App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simple_Ecommers_App.Api.dll"]
