CREATE TABLE todo_files (
    id SERIAL NOT NULL UNIQUE,
    todo_id INTEGER NOT NULL,
    file_name VARCHAR( 128 ) NOT NULL,

    CONSTRAINT pk_todo_files PRIMARY KEY ( id ),
    FOREIGN KEY ( todo_id ) REFERENCES todos( id )
);
