import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import AddCandidate from "./components/AddCandidate/AddCandidate";
import AddSkill from "./components/AddSkill/AddSkill";
import Candidates from "./components/Candidates/Candidates";
import EditCandidate from "./components/EditCandidateInfo/EditCandidate";
import Navbar from "./components/Navbar/Navbar";
import UpdateSkills from "./components/UpdateCandidateSkills/UpdateSkills";

function App() {
    return (
        <BrowserRouter>
            <div>
                <Navbar />
                <Routes>
                    <Route path="/" element={
                        <Candidates />
                    }></Route>
                    <Route path="/editCandidate/:id" element={
                        <EditCandidate />
                    }></Route>
                    <Route path="/addCandidate" element={
                        <AddCandidate />
                    }></Route>
                    <Route path="/addSkill" element={
                        <AddSkill />
                    }></Route>
                    <Route path="/updateSkills/:id" element={
                        <UpdateSkills />
                    }></Route>
                </Routes>
            </div>
        </BrowserRouter>
    );
}

export default App;
