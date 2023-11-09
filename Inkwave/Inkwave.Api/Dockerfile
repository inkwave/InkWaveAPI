#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Inkwave.Api/Inkwave.WebAPI.csproj", "Inkwave.Api/"]
COPY ["Inkwave.Application/Inkwave.Application.csproj", "Inkwave.Application/"]
COPY ["Inkwave.Domain/Inkwave.Domain.csproj", "Inkwave.Domain/"]
COPY ["Inkwave.Shared/Inkwave.Shared.csproj", "Inkwave.Shared/"]
COPY ["Inkwave.Infrastructure/Inkwave.Infrastructure.csproj", "Inkwave.Infrastructure/"]
COPY ["Inkwave.Presentation/Inkwave.Persistence.csproj", "Inkwave.Presentation/"]
RUN dotnet restore "Inkwave.Api/Inkwave.WebAPI.csproj"
COPY . .
WORKDIR "/src/Inkwave.Api"
RUN dotnet build "Inkwave.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inkwave.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inkwave.WebAPI.dll"]



FROM base AS final
WORKDIR /root/  
COPY --from=publish /root/src/app/Inkwave/published .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000/tcp
#CMD ["dotnet", "./aspnetcoreapp.dll"]  
CMD ["./aspnetcoreapp"] 