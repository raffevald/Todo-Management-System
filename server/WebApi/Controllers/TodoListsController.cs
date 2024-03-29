﻿using Application.Dtos.TodoList;
using Application.Helpers;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Application.Extensions;


namespace WebApi.Controllers {
    [Route ( "api/[controller]" )]
    [ApiController]
    public class TodoListsController : ControllerBase {
        private readonly IDataService _dataService;

        public TodoListsController ( IDataService dataService ) {
            _dataService = dataService;
        }

        [HttpGet ( "Get" )]
        public async Task<IActionResult> Get ( ) {
            var viewModels = await _dataService.TodoListsServices.Get();
            if ( viewModels == null || viewModels.Count <= 0 )
                return NotFound ( ApiResnposeBuilder.GenerateNotFound ( "Get failed", "Record not found" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( viewModels, "OK", $"{viewModels.Count} record(s) fetched" ) );
        }

        [HttpGet ( "Get/{id}" )]
        public async Task<IActionResult> Get ( int id ) {
            if ( id <= 0 )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Get failed", "Invalid input" ) );

            var modelDto = await _dataService.TodoListsServices.Get(id);
            if ( modelDto == null )
                return NotFound ( ApiResnposeBuilder.GenerateNotFound ( "Get failed", $"Record with id {id} not found" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( modelDto, "OK", $"Record with id {modelDto.Id} fetched" ) );
        }

        [HttpPost ( "Create" )]
        public async Task<IActionResult> Create ( [FromBody] TodoListDTO todoListDTO ) {
            if ( todoListDTO == null )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Create failed", "Input not valid or null" ) );

            if ( !ModelState.IsValid ) {
                var erros = ModelState.GetModelStateErros();
                if ( erros != null && erros.Count > 0 ) {
                    var msgBuilder = new StringBuilder();
                    foreach ( var error in erros ) {
                        msgBuilder.AppendLine ( error.ToString () );

                    }

                    return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Create failed", msgBuilder.ToString () ) );
                }
            }

            var createDto = await _dataService.TodoListsServices.Create(todoListDTO);
            if ( createDto == null )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Create failed", "Some error occured" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( createDto, "Created successfull", $"" ) );
        }

        [HttpPut ( "Update/{id}" )]
        public async Task<IActionResult> Update ( int id, [FromBody] TodoListDTO todoListDTO ) {
            if ( id <= 0 || todoListDTO == null || todoListDTO.Id != id )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Update failed", "Input not valid or null" ) );

            if ( !ModelState.IsValid ) {
                var erros = ModelState.GetModelStateErros();
                if ( erros != null && erros.Count > 0 ) {
                    var msgBuilder = new StringBuilder();
                    foreach ( var error in erros ) {
                        msgBuilder.AppendLine ( error.ToString () );

                    }

                    return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Update failed", msgBuilder.ToString () ) );
                }
            }

            var updateDto = await _dataService.TodoListsServices.Update( todoListDTO );
            if ( updateDto == null )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Update failed", "Some error occured" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( updateDto, "Update successfull", $"Record update successfull" ) );
        }

        [HttpDelete ( "Delete/{id}" )]
        public async Task<IActionResult> Delete ( int id ) {
            if ( id <= 0 )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Delete failed", "Input not valid" ) );

            var rowsAffected = await _dataService.TodoListsServices.Delete ( id );
            if ( rowsAffected <= 0 ) return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Delete failed", "There might be active child record(s)" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( rowsAffected, "OK", $"Record with id {id} deleted" ) );
        }

        [HttpPost ( "CreateRange" )]
        public async Task<IActionResult> CreateRange ( [FromBody] List<TodoListDTO> TodoListDTOs ) {
            if ( TodoListDTOs == null || TodoListDTOs.Count <= 0 )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk create failed", "Input not valid or null" ) );

            if ( !ModelState.IsValid ) {
                var erros = ModelState.GetModelStateErros();

                if ( erros != null && erros.Count > 0 ) {
                    var msgBuilder = new StringBuilder();

                    foreach ( var error in erros ) {
                        msgBuilder.AppendLine ( error.ToString () );

                    }

                    return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk create failed", msgBuilder.ToString () ) );
                }
            }

            var createDtos = await _dataService.TodoListsServices.CreateRange(TodoListDTOs);
            if ( createDtos == null )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk create failed", "Some error occured" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( createDtos, "OK", $"Bulk created successfull" ) );
        }

        [HttpPost ( "UpdateRange" )]
        public async Task<IActionResult> UpdateRange ( [FromBody] List<TodoListDTO> TodoListDTOs ) {
            if ( TodoListDTOs == null || TodoListDTOs.Count <= 0 )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk update failed", "Input not valid or null" ) );

            if ( !ModelState.IsValid ) {
                var erros = ModelState.GetModelStateErros();
                if ( erros != null && erros.Count > 0 ) {
                    var msgBuilder = new StringBuilder();
                    foreach ( var error in erros ) {
                        msgBuilder.AppendLine ( error.ToString () );

                    }

                    return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk update failed", msgBuilder.ToString () ) );
                }
            }

            var updateDtos = await _dataService.TodoListsServices.UpdateRange(TodoListDTOs);
            if ( updateDtos == null )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk update failed", "Some error occured" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( updateDtos, "OK", $"Bulk update successfull" ) );
        }

        [HttpPost ( "DeleteRange" )]
        public async Task<IActionResult> DeleteRange ( [FromBody] List<TodoListDTO> TodoListDTOs ) {
            if ( TodoListDTOs == null || TodoListDTOs.Count <= 0 )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk delete failed", "Input not valid or null" ) );

            if ( !ModelState.IsValid ) {
                var erros = ModelState.GetModelStateErros();
                if ( erros != null && erros.Count > 0 ) {
                    var msgBuilder = new StringBuilder();
                    foreach ( var error in erros ) {
                        msgBuilder.AppendLine ( error.ToString () );

                    }

                    return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk delete failed", msgBuilder.ToString () ) );
                }
            }

            var rowsAffected = await _dataService.TodoListsServices.DeleteRange(TodoListDTOs);
            if ( rowsAffected <= 0 )
                return BadRequest ( ApiResnposeBuilder.GenerateBadRequest ( "Bulk delete failed", "Some error occured" ) );

            return Ok ( ApiResnposeBuilder.GenerateOk ( rowsAffected, "OK", $"Bulk delete successfull" ) );
        }

    }

}

