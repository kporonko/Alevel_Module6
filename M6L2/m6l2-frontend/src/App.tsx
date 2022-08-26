import React, {useEffect, useState} from 'react';
import Header from "./components/Header";
import BookList from "./components/BookList";
import {GetBooks} from "./fetch";
import {IBook} from "./interfaces/IBook";

const App = () => {

    const [books, setBooks] = useState<IBook[]>([])

    useEffect(() => {
        const fetchProductsData = async () => {
            const res = await GetBooks();
            setBooks(res);
        }
        fetchProductsData();
    }, [])

    return (
        <div>
            <Header/>
            {books.length > 0 ? <BookList books={books}/> : ''}
        </div>
    );
};

export default App;