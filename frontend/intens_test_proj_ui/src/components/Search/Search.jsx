import React from 'react'
import './search.css'

const Search = ({handleSearchSubmit, setSearchText}) => {
    return (
        <form className='search' onSubmit={(e) => handleSearchSubmit(e)}>
            <input 
                type="text" 
                placeholder='Enter candidate name or skill' 
                onChange={(e) => setSearchText(e.target.value)}
            />
            <button type='submit'>Submit</button>
        </form>
    )
}

export default Search