﻿CREATE TABLE posts (
  post_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  text TEXT,
  creation_date TIMESTAMP NOT NULL
);

INSERT INTO posts (text, creation_date)
  VALUES ('Test1', '2021-01-14');
INSERT INTO posts (text, creation_date)
  VALUES (NULL, '2021-02-15');

CREATE TABLE comment2s (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    text TEXT NULL
);

CREATE TABLE table3s (
    id INT PRIMARY KEY,
    text TEXT NULL
);

CREATE TABLE table4s (
    id INT PRIMARY KEY,
    first_name TEXT NULL
);

INSERT INTO table4s (id, first_name)
VALUES (1, 'Test1');

CREATE TABLE table5s (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    creation_date TIMESTAMP
);
