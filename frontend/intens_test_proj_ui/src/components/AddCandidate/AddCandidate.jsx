import React, {useState} from 'react'
import './addCandidate.css'
import backend from '../../api/backend'
import { useNavigate } from 'react-router-dom'

const AddCandidate = () => {
    const navigate = useNavigate();
    const [candidate, setCandidate] = useState({fullName:'', dateOfBirth:'', contactNumber:'', email:''});

    const addCandidate = async () => {
        try {
            await backend.post(`/JobCandidate/addCandidate`, candidate);
            window.confirm("Candidate was added")
            navigate('/');
        } catch (error) {
            alert(error);
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        addCandidate();
    }

    return (
        <form className='formTemplate' onSubmit={(e) => handleSubmit(e)}>
            <label>
                FullName:
                <input type="text" onChange={(e) => setCandidate(prevState => ({ ...prevState, fullName: e.target.value }))} />
            </label>     
            <label>
                Contact Number:
                <input type="tel" onChange={(e) => setCandidate(prevState => ({ ...prevState, contactNumber: e.target.value }))} />
            </label>
            <label>
                Email:
                <input type="text" onChange={(e) => setCandidate(prevState => ({ ...prevState, email: e.target.value }))} />
            </label>
            <label>
                Date of birth:
                <input type="date" onChange={(e) => setCandidate(prevState => ({ ...prevState, dateOfBirth: e.target.value }))} />
            </label>
            
            <button type='submit'>Submit</button>
        </form>
    )
}

export default AddCandidate