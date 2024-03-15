create database todo_ms_development;

CREATE TABLE todo_groups (
    id SERIAL NOT NULL UNIQUE,
    group_name VARCHAR( 128 ) NOT NULL,
    create_on TIMESTAMP NOT NULL,

    CONSTRAINT pk_todo_groups PRIMARY KEY ( id )
);
