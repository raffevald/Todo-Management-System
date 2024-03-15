CREATE TABLE todo_notes (
    id SERIAL NOT NULL UNIQUE,
    todo_id INTEGER NOT NULL,
    title VARCHAR( 128 ) NOT NULL,
    description VARCHAR( 512 ) NOT NULL,

    CONSTRAINT pk_todo_notes PRIMARY KEY ( id ),
    FOREIGN KEY ( todo_id ) REFERENCES todos( id )
);
