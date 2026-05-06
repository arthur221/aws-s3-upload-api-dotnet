# AWS S3 Upload API (.NET)

Simple project created to study integration between .NET and AWS S3.

The application allows file uploads to an S3 bucket using an ASP.NET Core API.

---

# Technologies Used

- .NET
- ASP.NET Core
- AWS S3
- AWS SDK
- Swagger

---

#  Configuration

## appsettings.json

```json
{
  "AWS": {
    "Region": "sa-east-1",
    "BucketName": "arthur-s3-estudos"
  }
}
```

---

# AWS Credentials

This project supports two ways to configure AWS credentials.

## Option 1 — appsettings.json

You can configure credentials directly inside `appsettings.json`:

```json
{
  "AWS": {
    "Region": "sa-east-1",
    "BucketName": "arthur-s3-estudos",
    "AccessKey": "YOUR_ACCESS_KEY",
    "SecretKey": "YOUR_SECRET_KEY"
  }
}
```

Example inside the service:

```csharp
public S3Service(IConfiguration configuration)
{
    var region = configuration["AWS:Region"];
    var accessKey = configuration["AWS:AccessKey"];
    var secretKey = configuration["AWS:SecretKey"];

    _bucketName = configuration["AWS:BucketName"];

    _s3Client = new AmazonS3Client(
        accessKey,
        secretKey,
        RegionEndpoint.GetBySystemName(region)
    );
}
```

---

## Option 2 — Environment Variables (Recommended)

You can also configure credentials using environment variables:

```bash
export AWS_ACCESS_KEY_ID=YOUR_ACCESS_KEY
export AWS_SECRET_ACCESS_KEY=YOUR_SECRET_KEY
```

Then the service can use:

```csharp
public S3Service(IConfiguration configuration)
{
    var region = configuration["AWS:Region"];
    _bucketName = configuration["AWS:BucketName"];

    _s3Client = new AmazonS3Client(
        RegionEndpoint.GetBySystemName(region)
    );
}
```

The AWS SDK automatically reads the credentials from the environment.

---

# Running the Project

## Install dependencies

```bash
dotnet restore
```

## Run the application

```bash
dotnet run
```

---

# Testing Upload

Open Swagger:

```bash
http://localhost:5045/swagger
```

Use:

```bash
POST /upload
```

Select a file and execute the request.

---

# Purpose

This project was developed to practice:

- AWS S3
- Cloud integration
- File upload handling
- Credential management
- Building APIs with .NET
