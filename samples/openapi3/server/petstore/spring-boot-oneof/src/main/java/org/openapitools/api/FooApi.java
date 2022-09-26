/**
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech) (6.2.1-SNAPSHOT).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
package org.openapitools.api;

import org.openapitools.model.Foo;
import org.openapitools.model.FooRefOrValue;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.Parameter;
import io.swagger.v3.oas.annotations.Parameters;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.security.SecurityRequirement;
import io.swagger.v3.oas.annotations.tags.Tag;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.context.request.NativeWebRequest;
import org.springframework.web.multipart.MultipartFile;

import javax.validation.Valid;
import javax.validation.constraints.*;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import javax.annotation.Generated;

@Generated(value = "org.openapitools.codegen.languages.SpringCodegen")
@Validated
@Tag(name = "foo", description = "the foo API")
@RequestMapping("${openapi.byRefOrValue.base-path:}")
public interface FooApi {

    default Optional<NativeWebRequest> getRequest() {
        return Optional.empty();
    }

    /**
     * POST /foo : Create a Foo
     *
     * @param foo The Foo to be created (optional)
     * @return Error (status code 201)
     */
    @Operation(
        operationId = "createFoo",
        summary = "Create a Foo",
        tags = { "Foo" },
        responses = {
            @ApiResponse(responseCode = "201", description = "Error", content = {
                @Content(mediaType = "application/json", schema = @Schema(implementation = FooRefOrValue.class))
            })
        }
    )
    @RequestMapping(
        method = RequestMethod.POST,
        value = "/foo",
        produces = { "application/json" },
        consumes = { "application/json;charset=utf-8" }
    )
    default ResponseEntity<FooRefOrValue> createFoo(
        @Parameter(name = "Foo", description = "The Foo to be created") @Valid @RequestBody(required = false) Foo foo
    ) {
        getRequest().ifPresent(request -> {
            for (MediaType mediaType: MediaType.parseMediaTypes(request.getHeader("Accept"))) {
                if (mediaType.isCompatibleWith(MediaType.valueOf("application/json"))) {
                    String exampleString = "null";
                    ApiUtil.setExampleResponse(request, "application/json", exampleString);
                    break;
                }
            }
        });
        return new ResponseEntity<>(HttpStatus.NOT_IMPLEMENTED);

    }


    /**
     * GET /foo : GET all Foos
     *
     * @return Success (status code 200)
     */
    @Operation(
        operationId = "getAllFoos",
        summary = "GET all Foos",
        tags = { "Foo" },
        responses = {
            @ApiResponse(responseCode = "200", description = "Success", content = {
                @Content(mediaType = "application/json;charset=utf-8", schema = @Schema(implementation = FooRefOrValue.class))
            })
        }
    )
    @RequestMapping(
        method = RequestMethod.GET,
        value = "/foo",
        produces = { "application/json;charset=utf-8" }
    )
    default ResponseEntity<List<FooRefOrValue>> getAllFoos(
        
    ) {
        getRequest().ifPresent(request -> {
            for (MediaType mediaType: MediaType.parseMediaTypes(request.getHeader("Accept"))) {
                if (mediaType.isCompatibleWith(MediaType.valueOf("application/json;charset=utf-8"))) {
                    String exampleString = "null";
                    ApiUtil.setExampleResponse(request, "application/json;charset=utf-8", exampleString);
                    break;
                }
            }
        });
        return new ResponseEntity<>(HttpStatus.NOT_IMPLEMENTED);

    }

}
