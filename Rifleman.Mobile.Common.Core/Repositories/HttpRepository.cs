using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.Classes.Constants;

namespace Rifleman.Mobile.Common.Core.Repositories
{
	public class HttpRepository
	{
		#region GET

		protected async Task<Response<byte[ ]>> GetFileAsync( string endPoint, Guid consumerKey, IProgress<DownloadProgress> progressReporter )
		{
			int receivedBytes = 0;
			Response<byte[ ]> responseModel;

			using ( HttpClient httpClient = GetHttpClient( consumerKey, string.Empty, TimeoutConstants.FileUploadSeconds ) )
			{
				try
				{
					using ( Stream stream = await httpClient.GetStreamAsync( endPoint ) )
					{
						byte[ ] buffer = new byte[ 4096 ];
						int totalBytes = ( int )stream.Length;

						using ( MemoryStream ms = new MemoryStream( ) )
						{
							while ( true )
							{
								int bytesRead = await stream.ReadAsync( buffer, 0, buffer.Length );
								if ( bytesRead == 0 )
								{
									await Task.Yield( );
									break;
								}

								receivedBytes += bytesRead;
								if ( progressReporter != null )
								{
									DownloadProgress args = new DownloadProgress( endPoint, receivedBytes, totalBytes );
									progressReporter.Report( args );
								}

								ms.Write( buffer, 0, bytesRead );
							}

							return new Response<byte[ ]>( ms.ToArray( ), HttpStatusCode.OK, true );
						}
					}

				}
				catch ( Exception )
				{
					responseModel = new Response<byte[ ]>( default( byte[ ] ), HttpStatusCode.ServiceUnavailable, false );
				}
			}

			return responseModel;
		}

		protected async Task<Response<TOutputModel>> GetAsync<TOutputModel>( string endPoint, Guid consumerKey, CancellationToken ct = default( CancellationToken ) )
		{
			Response<TOutputModel> responseModel;

			using ( HttpClient httpClient = GetHttpClient( consumerKey, "application/json", TimeoutConstants.ConnectionSeconds ) )
			{
				try
				{
					await Task.Delay( 150 );
					HttpResponseMessage response = await httpClient.GetAsync( endPoint, ct );

					if ( response.IsSuccessStatusCode )
					{
						string json = await response.Content.ReadAsStringAsync( );
						TOutputModel model = JsonConvert.DeserializeObject<TOutputModel>( json );
						responseModel = new Response<TOutputModel>( model, response.StatusCode, true );
					}
					else
					{
						responseModel = new Response<TOutputModel>( default( TOutputModel ), response.StatusCode, false );
					}
				}
				catch ( Exception )
				{
					responseModel = new Response<TOutputModel>( default( TOutputModel ), HttpStatusCode.ServiceUnavailable, false );
				}
			}

			return responseModel;
		}

		#endregion


		#region POST

		protected async Task<Response<TOutputModel>> PostFileAsync<TOutputModel, T>( string endPoint, Guid consumerKey, T inputModel )
		{
			Response<TOutputModel> responseModel;

			using ( HttpClient httpClient = GetHttpClient( consumerKey, "application/bson", TimeoutConstants.FileUploadSeconds ) )
			{
				try
				{
					HttpResponseMessage response = await httpClient.PostAsync( endPoint, SerializeBson( inputModel ) );

					if ( response.IsSuccessStatusCode )
					{
						TOutputModel model = DeserializeBson<TOutputModel>( await response.Content.ReadAsByteArrayAsync( ) );
						responseModel = new Response<TOutputModel>( model, response.StatusCode, true );
					}
					else
					{
						responseModel = new Response<TOutputModel>( default( TOutputModel ), response.StatusCode, false );
					}
				}
				catch ( Exception )
				{
					responseModel = new Response<TOutputModel>( default( TOutputModel ), HttpStatusCode.ServiceUnavailable, false );
				}
			}

			return responseModel;
		}

		protected async Task<Response<TOutputModel>> PostAsync<TOutputModel, T>( string endPoint, Guid consumerKey, T inputModel, CancellationToken ct = default( CancellationToken ) )
		{
			Response<TOutputModel> responseModel;

			using ( HttpClient httpClient = GetHttpClient( consumerKey, "application/json", TimeoutConstants.ConnectionSeconds ) )
			{
				try
				{
					string modelAsJson = JsonConvert.SerializeObject( inputModel );
					StringContent jsonAsString = new StringContent( modelAsJson, Encoding.UTF8, "application/json" );
					HttpResponseMessage response = await httpClient.PostAsync( endPoint, jsonAsString, ct );

					if ( response.IsSuccessStatusCode )
					{
						TOutputModel model = JsonConvert.DeserializeObject<TOutputModel>( await response.Content.ReadAsStringAsync( ) );
						responseModel = new Response<TOutputModel>( model, response.StatusCode, true );
					}
					else
					{
						responseModel = new Response<TOutputModel>( default( TOutputModel ), response.StatusCode, false );
					}
				}
				catch ( Exception )
				{
					responseModel = new Response<TOutputModel>( default( TOutputModel ), HttpStatusCode.ServiceUnavailable, false );
				}
			}

			return responseModel;
		}

		#endregion

		#region Static Helper Methods

		private static HttpClient GetHttpClient( Guid consumerKey, string mediaType, int timeoutSeconds )
		{
			HttpClient httpClient = new HttpClient( );

			httpClient.DefaultRequestHeaders.Accept.Clear( );
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", consumerKey.ToString( FormattingConstants.Dashes ) );

			if ( !string.IsNullOrWhiteSpace( mediaType ) )
			{
				httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( mediaType ) );
			}

			httpClient.Timeout = TimeSpan.FromSeconds( timeoutSeconds );

			return httpClient;
		}

		private static ByteArrayContent SerializeBson<T>( T obj )
		{
			using ( MemoryStream ms = new MemoryStream( ) )
			{
				using ( BsonDataWriter writer = new BsonDataWriter( ms ) )
				{
					JsonSerializer serializer = new JsonSerializer( );
					serializer.Serialize( writer, obj );
				}

				ByteArrayContent byteArrayContent = new ByteArrayContent( ms.ToArray( ) );
				byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue( "application/bson" );

				return byteArrayContent;
			}
		}

		private static TOut DeserializeBson<TOut>( byte[ ] data )
		{
			using ( MemoryStream ms = new MemoryStream( data ) )
			{
				using ( BsonDataReader bsonReader = new BsonDataReader( ms ) )
				{
					JsonSerializer serializer = new JsonSerializer( );
					return serializer.Deserialize<TOut>( bsonReader );
				}
			}
		}

		#endregion
	}
}
