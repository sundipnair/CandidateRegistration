FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CandidateRegistration.csproj", "CandidateRegistration/"]
RUN dotnet restore "CandidateRegistration/CandidateRegistration.csproj"
WORKDIR "/src/CandidateRegistration"
COPY . .
RUN dotnet build "CandidateRegistration.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CandidateRegistration.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CandidateRegistration.dll"]