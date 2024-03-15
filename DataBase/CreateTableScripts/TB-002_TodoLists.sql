CREATE TABLE todo_lists (
    id SERIAL NOT NULL UNIQUE,
    todo_group_id INTEGER,
    list_name VARCHAR( 128 ) NOT NULL,
    create_on TIMESTAMP NOT NULL,

    CONSTRAINT pk_todo_lists PRIMARY KEY ( id ),
    FOREIGN KEY ( todo_group_id ) REFERENCES todo_groups( id )
);
