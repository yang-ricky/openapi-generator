# coding: utf-8

"""


    Generated by: https://openapi-generator.tech
"""

import unittest
from unittest.mock import patch

import urllib3

import unit_test_api
from unit_test_api.paths.request_body_post_by_number_request_body import post  # noqa: E501
from unit_test_api import configuration, schemas, api_client

from .. import ApiTestMixin


class TestRequestBodyPostByNumberRequestBody(ApiTestMixin, unittest.TestCase):
    """
    RequestBodyPostByNumberRequestBody unit test stubs
    """
    _configuration = configuration.Configuration()

    def setUp(self):
        used_api_client = api_client.ApiClient(configuration=self._configuration)
        self.api = post.ApiForpost(api_client=used_api_client)  # noqa: E501

    def tearDown(self):
        pass

    response_status = 200
    response_body = ''

    def test_45_is_multiple_of15_passes(self):
        content_type = 'application/json'
        # 4.5 is multiple of 1.5
        with patch.object(urllib3.PoolManager, 'request') as mock_request:
            payload = (
                4.5
            )
            body = post.SchemaForRequestBodyApplicationJson.from_openapi_data_oapg(
                payload,
                _configuration=self._configuration
            )
            mock_request.return_value = self.response(
                self.json_bytes(self.response_body),
                status=self.response_status
            )
            api_response = self.api.post(
                body=body,
                content_type=content_type
            )
            self.assert_pool_manager_request_called_with(
                mock_request,
                self._configuration.host + '/requestBody/postByNumberRequestBody',
                method='post'.upper(),
                body=self.json_bytes(payload),
                content_type=content_type,
            )

            assert isinstance(api_response.response, urllib3.HTTPResponse)
            assert isinstance(api_response.body, schemas.Unset)

    def test_35_is_not_multiple_of15_fails(self):
        content_type = 'application/json'
        # 35 is not multiple of 1.5
        with patch.object(urllib3.PoolManager, 'request') as mock_request:
            payload = (
                35
            )
            with self.assertRaises((unit_test_api.ApiValueError, unit_test_api.ApiTypeError)):
                body = post.SchemaForRequestBodyApplicationJson.from_openapi_data_oapg(
                    payload,
                    _configuration=self._configuration
                )
                self.api.post(body=body)

    def test_zero_is_multiple_of_anything_passes(self):
        content_type = 'application/json'
        # zero is multiple of anything
        with patch.object(urllib3.PoolManager, 'request') as mock_request:
            payload = (
                0
            )
            body = post.SchemaForRequestBodyApplicationJson.from_openapi_data_oapg(
                payload,
                _configuration=self._configuration
            )
            mock_request.return_value = self.response(
                self.json_bytes(self.response_body),
                status=self.response_status
            )
            api_response = self.api.post(
                body=body,
                content_type=content_type
            )
            self.assert_pool_manager_request_called_with(
                mock_request,
                self._configuration.host + '/requestBody/postByNumberRequestBody',
                method='post'.upper(),
                body=self.json_bytes(payload),
                content_type=content_type,
            )

            assert isinstance(api_response.response, urllib3.HTTPResponse)
            assert isinstance(api_response.body, schemas.Unset)




if __name__ == '__main__':
    unittest.main()