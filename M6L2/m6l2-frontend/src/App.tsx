import React, {useEffect, useState} from 'react';
import Header from "./components/Header";
import BookList from "./components/BookList";
import {DeleteBook, GetBooks} from "./fetch";
import {IBook} from "./interfaces/IBook";
import {Route, Routes} from "react-router-dom";
import BookDescription from "./components/BookDescription";
import AddBook from "./components/AddBook";

const App = () => {

    const [books, setBooks] = useState<IBook[]>([])

    useEffect(() => {
        const fetchProductsData = async () => {
            const res = await GetBooks();
            setBooks(res);
        }
        fetchProductsData();
    }, [])

    async function deleteBook(id: number){
        await DeleteBook(id);
        await window.location.reload();
    }

    return (
        <div>
            <Header/>
            <Routes>
                <Route path='/' element={books.length > 0 ? <BookList onDelete={deleteBook} books={books}/> : ''}/>
                <Route path="/book/:id" element={<BookDescription/>} />
                <Route path="/addBook" element={<AddBook/>} />
            </Routes>

        </div>
    );
};

export default App;