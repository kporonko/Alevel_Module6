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