import React, {useState} from 'react';
import {IBook} from "../interfaces/IBook";
import {IBookAuthor} from "../interfaces/IBookAuthor";
import {IAuthor} from "../interfaces/IAuthor";
import {addBook} from "../fetch";
import {useNavigate} from "react-router-dom";

const AddBook = () => {

    const [bookDescription, setBookDescription] = useState<IBook>({
        bookId: -1,
        releaseYear: 0,
        booksAuthors: [],
        description: "",
        title: ""
    })
    const [bookAuthor, setBookAuthor] = useState<IBookAuthor>({
        author: {
            authorId: -1,
            lastName : "",
            firstName: "",
            birthday: new Date()
        }, contribution: "", description: "", releaseYear: 0
    })

    const [author, setAuthor] = useState<IAuthor>({
        authorId: -1, birthday: new Date(), firstName: "", lastName: ""
    })

    const nav = useNavigate()

    const handleSubmit = async (e: any) => {
        e.preventDefault()
        await addBook(bookDescription.title, bookDescription.releaseYear, bookDescription.description, [{
            firstName: author.firstName, lastName: author.lastName, contribution: bookAuthor.contribution, birthday: author.birthday
        }]);
        // window.location.reload();
    }

        return (
        <div>
            <form className='form-admin' onSubmit={handleSubmit} action="">
                <p>
                    <label htmlFor="">Title</label>
                    <input onChange={(e) => setBookDescription({...bookDescription, title: e.target.value})} type="text" value={bookDescription.title}/>
                </p>
                <p>
                    <label htmlFor="">Release Year</label>
                    <input type='number' onChange={(e) => setBookDescription({...bookDescription, releaseYear: +e.target.value})}  value={bookDescription.releaseYear}/>
                </p>
                <p>
                    <label htmlFor="">Description</label>
                    <textarea onChange={(e) => setBookDescription({...bookDescription, description: e.target.value})} rows={5} cols={20} value={bookDescription.description}/>
                </p>

                    <p>
                        <label htmlFor="">FirstName</label>
                        <input type='text' onChange={(e) => setAuthor({...author, firstName: e.target.value})}  className="author-input"/>
                    </p>
                    <p>
                        <label htmlFor="">LastName</label>
                        <input type='text' onChange={(e) => setAuthor({...author, lastName: e.target.value})} className="author-input"/>
                    </p>
                    <p>
                        <label htmlFor="">Contribution</label>
                        <input type='text' onChange={(e) => setBookAuthor({...bookAuthor, contribution: e.target.value})}  className="author-input"/>
                    </p>
                    <p>
                        <label htmlFor="">DateOfBirth</label>
                        <input type='date' onChange={(e) => setAuthor({...author, birthday: new Date(e.target.value)})}/>
                    </p>

                <p>
                    <button type='submit'>Add</button>
                </p>
            </form>
        </div>
    );
};

export default AddBook;