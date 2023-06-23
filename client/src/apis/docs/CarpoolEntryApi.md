# OpenapiClient::CarpoolEntryApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
| ------ | ------------ | ----------- |
| [**api_carpool_entry_get**](CarpoolEntryApi.md#api_carpool_entry_get) | **GET** /api/CarpoolEntry |  |
| [**api_carpool_entry_id_delete**](CarpoolEntryApi.md#api_carpool_entry_id_delete) | **DELETE** /api/CarpoolEntry/{id} |  |
| [**api_carpool_entry_id_get**](CarpoolEntryApi.md#api_carpool_entry_id_get) | **GET** /api/CarpoolEntry/{id} |  |
| [**api_carpool_entry_id_put**](CarpoolEntryApi.md#api_carpool_entry_id_put) | **PUT** /api/CarpoolEntry/{id} |  |
| [**api_carpool_entry_post**](CarpoolEntryApi.md#api_carpool_entry_post) | **POST** /api/CarpoolEntry |  |


## api_carpool_entry_get

> api_carpool_entry_get



### Examples

```ruby
require 'time'
require 'openapi_client'

api_instance = OpenapiClient::CarpoolEntryApi.new

begin
  
  api_instance.api_carpool_entry_get
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_get: #{e}"
end
```

#### Using the api_carpool_entry_get_with_http_info variant

This returns an Array which contains the response data (`nil` in this case), status code and headers.

> <Array(nil, Integer, Hash)> api_carpool_entry_get_with_http_info

```ruby
begin
  
  data, status_code, headers = api_instance.api_carpool_entry_get_with_http_info
  p status_code # => 2xx
  p headers # => { ... }
  p data # => nil
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_get_with_http_info: #{e}"
end
```

### Parameters

This endpoint does not need any parameter.

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


## api_carpool_entry_id_delete

> api_carpool_entry_id_delete(id)



### Examples

```ruby
require 'time'
require 'openapi_client'

api_instance = OpenapiClient::CarpoolEntryApi.new
id = 56 # Integer | 

begin
  
  api_instance.api_carpool_entry_id_delete(id)
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_id_delete: #{e}"
end
```

#### Using the api_carpool_entry_id_delete_with_http_info variant

This returns an Array which contains the response data (`nil` in this case), status code and headers.

> <Array(nil, Integer, Hash)> api_carpool_entry_id_delete_with_http_info(id)

```ruby
begin
  
  data, status_code, headers = api_instance.api_carpool_entry_id_delete_with_http_info(id)
  p status_code # => 2xx
  p headers # => { ... }
  p data # => nil
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_id_delete_with_http_info: #{e}"
end
```

### Parameters

| Name | Type | Description | Notes |
| ---- | ---- | ----------- | ----- |
| **id** | **Integer** |  |  |

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## api_carpool_entry_id_get

> api_carpool_entry_id_get(id)



### Examples

```ruby
require 'time'
require 'openapi_client'

api_instance = OpenapiClient::CarpoolEntryApi.new
id = 56 # Integer | 

begin
  
  api_instance.api_carpool_entry_id_get(id)
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_id_get: #{e}"
end
```

#### Using the api_carpool_entry_id_get_with_http_info variant

This returns an Array which contains the response data (`nil` in this case), status code and headers.

> <Array(nil, Integer, Hash)> api_carpool_entry_id_get_with_http_info(id)

```ruby
begin
  
  data, status_code, headers = api_instance.api_carpool_entry_id_get_with_http_info(id)
  p status_code # => 2xx
  p headers # => { ... }
  p data # => nil
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_id_get_with_http_info: #{e}"
end
```

### Parameters

| Name | Type | Description | Notes |
| ---- | ---- | ----------- | ----- |
| **id** | **Integer** |  |  |

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## api_carpool_entry_id_put

> api_carpool_entry_id_put(id, opts)



### Examples

```ruby
require 'time'
require 'openapi_client'

api_instance = OpenapiClient::CarpoolEntryApi.new
id = 56 # Integer | 
opts = {
  carpool_entry: OpenapiClient::CarpoolEntry.new # CarpoolEntry | 
}

begin
  
  api_instance.api_carpool_entry_id_put(id, opts)
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_id_put: #{e}"
end
```

#### Using the api_carpool_entry_id_put_with_http_info variant

This returns an Array which contains the response data (`nil` in this case), status code and headers.

> <Array(nil, Integer, Hash)> api_carpool_entry_id_put_with_http_info(id, opts)

```ruby
begin
  
  data, status_code, headers = api_instance.api_carpool_entry_id_put_with_http_info(id, opts)
  p status_code # => 2xx
  p headers # => { ... }
  p data # => nil
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_id_put_with_http_info: #{e}"
end
```

### Parameters

| Name | Type | Description | Notes |
| ---- | ---- | ----------- | ----- |
| **id** | **Integer** |  |  |
| **carpool_entry** | [**CarpoolEntry**](CarpoolEntry.md) |  | [optional] |

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json


## api_carpool_entry_post

> api_carpool_entry_post(opts)



### Examples

```ruby
require 'time'
require 'openapi_client'

api_instance = OpenapiClient::CarpoolEntryApi.new
opts = {
  carpool_entry: OpenapiClient::CarpoolEntry.new # CarpoolEntry | 
}

begin
  
  api_instance.api_carpool_entry_post(opts)
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_post: #{e}"
end
```

#### Using the api_carpool_entry_post_with_http_info variant

This returns an Array which contains the response data (`nil` in this case), status code and headers.

> <Array(nil, Integer, Hash)> api_carpool_entry_post_with_http_info(opts)

```ruby
begin
  
  data, status_code, headers = api_instance.api_carpool_entry_post_with_http_info(opts)
  p status_code # => 2xx
  p headers # => { ... }
  p data # => nil
rescue OpenapiClient::ApiError => e
  puts "Error when calling CarpoolEntryApi->api_carpool_entry_post_with_http_info: #{e}"
end
```

### Parameters

| Name | Type | Description | Notes |
| ---- | ---- | ----------- | ----- |
| **carpool_entry** | [**CarpoolEntry**](CarpoolEntry.md) |  | [optional] |

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

