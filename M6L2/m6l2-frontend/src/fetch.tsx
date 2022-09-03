import React from 'react';

const baseUrl = 'http://localhost:8182/'
export const GetBooks = async () => {
    const response = await fetch(`${baseUrl}Books/books`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }});

    const body = await response.json();
    console.log(body)
    return body;
}

export const DeleteBook = async (id: number) => {
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ id: id })
    };

    const response = await fetch(`${baseUrl}Books/book`, requestOptions);

    const body = await response.json();
    console.log(body)
    return body;
}



export const bookById = async (id: string) => {
    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    const response = await fetch(`${baseUrl}Books/book/${+id}`, requestOptions);

    const body = await response.json();
    console.log(body)
    return body;
}

export const updateBook = async (id: string, title: string, description: string) => {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({id: id, title: title, description: description })
    };
    const response = await fetch(`${baseUrl}Books/book`, requestOptions);
}

interface addBookAuthors{
    lastName: string,
    firstName: string,
    contribution: string,
    birthday: Date
}
export const addBook = async (title: string, releaseYear: number, description: string, authors: addBookAuthors[]) => {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: title, description: description, releaseYear: releaseYear, authors : authors})
    };
    console.log(requestOptions.body)
    const response = await fetch(`${baseUrl}Books/book`, requestOptions);
}
