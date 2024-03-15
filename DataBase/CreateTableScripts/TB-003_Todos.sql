CREATE TABLE todos (
    id SERIAL NOT NULL UNIQUE,
    todo_list_id INTEGER,
    todo_item VARCHAR( 512 ) NOT NULL,
    create_on TIMESTAMP NOT NULL,
    due_date TIMESTAMP,
    reminder_date TIMESTAMP,
    repeat VARCHAR( 32 ),
    important BOOLEAN NOT NULL,
    completed BOOLEAN NOT NULL,

    CONSTRAINT pk_todos PRIMARY KEY ( id ),
    FOREIGN KEY ( todo_list_id ) REFERENCES todo_lists( id )
);
