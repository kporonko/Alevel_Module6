import React from 'react';


export const GetBooks = async () => {
    const response = await fetch('https://localhost:7245/Books/books', {
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

    const response = await fetch('https://localhost:7245/Books/book', requestOptions);

    const body = await response.json();
    console.log(body)
    return body;
}



export const bookById = async (id: string) => {
    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    const response = await fetch(`https://localhost:7245/Books/book/${+id}`, requestOptions);

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

    const response = await fetch(`https://localhost:7245/Books/book`, requestOptions);
}
