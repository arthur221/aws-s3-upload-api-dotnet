using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

public class S3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3Service(IConfiguration configuration)
    {
        var region = configuration["AWS:Region"];
        _bucketName = configuration["AWS:BucketName"];

        _s3Client = new AmazonS3Client(
            RegionEndpoint.GetBySystemName(region)
        );
    }

    public async Task UploadFileAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = stream,
            Key = file.FileName,
            BucketName = _bucketName,
            ContentType = file.ContentType
        };

        var transferUtility = new TransferUtility(_s3Client);
        await transferUtility.UploadAsync(uploadRequest);
    }
}