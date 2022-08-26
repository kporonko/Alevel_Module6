import React, {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import {bookById, updateBook} from "../fetch";
import {Simulate} from "react-dom/test-utils";
import {IBook} from "../interfaces/IBook";
import book from "./Book";

const BookDescription = () => {

    const {id} = useParams()
    const [bookDescription, setBookDescription] = useState<IBook>({
        bookId: -1,
        booksAuthors: [],
        description: "",
        releaseYear: 0,
        title: ""
    })

    useEffect(() => {
        const fetch = async (id:string) => {
            const res = await bookById(id);
            setBookDescription(res)
        }
        if (id !== undefined){
            fetch(id);
        }
    }, [id])


    const submit = async (e: any) => {
        e.preventDefault();
        if (id){
            await updateBook(id,bookDescription.title, bookDescription.description, );
        }
        window.location.reload()
    }

    return (
        <div className='full-desc'>
            {bookDescription.bookId < 0 ? '' : (
                <form onSubmit={submit}>
                    <div>
                        <input style={{margin: '10px 0'}} onChange={(e)=>{setBookDescription({...bookDescription, title: e.target.value})}} type="text" value={bookDescription.title}/>
                    </div>
                    <div>
                        <textarea style={{margin: '10px 0'}} onChange={(e)=>{setBookDescription({...bookDescription, description: e.target.value})}} value={bookDescription.description} name="" id="" cols={30} rows={10}></textarea>
                    </div>
                    <div style={{display: 'flex', justifyContent: 'center'}}>
                        <button type='submit'>Change</button>
                    </div>
                </form>
            )}
        </div>
    );
};

export default BookDescription;