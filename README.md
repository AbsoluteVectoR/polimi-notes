# Polimi notes 

This is a collection of my notes for various **Computer Science and Engineering** courses that I attended. The repo includes:
- **Master's degree course notes (Work In Progress):**
    - All notes are in English
    - Some course notes are incomplete since still in progress or boring 
- **Bachelor's degree course notes:**
	- All notes are in Italian, except for Foundations of AI
    - Notes are available only for some courses of the study plan

These notes were created during periods of desperate studying, utilizing both professor-provided materials and resources from fellow students. They are not intended to be perfect and may be inaccurate and incomplete. If you see any error feel free to open an issue or send a pull request.


![carousel](https://user-images.githubusercontent.com/72280379/229372373-9c14d105-22c7-4205-a9c3-34a42619d13f.gif)


## Main features 

- Every course note is divided in macro subjects plain markdown notes but it has also a PDF file in [realeses](https://github.com/martinopiaggi/polimi-notes/releases). 
- Topics are **interconnected** through **markdown links**, allowing for easy navigation and exploration of related topics directly from Github (*yeah still not enough connection .. Work In Progress*).
- **Courses marked with WIP are incomplete** as I am still working on them, studying them, or procrastinating the note refactoring.
- If you open this repository with Obsidian.md (or similar softwares) you also have a one-click graph visualization of the notes interconnections.

![graph](https://user-images.githubusercontent.com/72280379/229372400-47b85c58-e2db-479b-a715-1fd869dbcc09.gif)


## Courses index

````
.
├── BSc(italian)
│   ├── Algoritmi e Principi dell'Informatica
│   ├── Analisi 2 (WIP)
│   ├── Basi di Dati
│   ├── Economia e Organizzazione Aziendale
│   ├── Fondamenti di Automatica
│   ├── Fondamenti di Elettronica
│   ├── Foundations of Artificial Intelligence
│   ├── Ingegneria del Software
│   ├── Meccanica
│   ├── Probabilità e Statistica per l'Informatica
│   ├── Progetto di Ingegneria Informatica
│   ├── Progetto di Ingegneria del Software
│   ├── Reti Logiche
│   └── Sistemi Informativi
└── MSc(english) (WIP)
    ├── Advanced Algorithms and Parallel Programming
    ├── Advanced Computer Architectures (WIP)
    ├── Computer Graphics(WIP)
    ├── Computer Security (WIP)
    ├── Computing Infrastructures (WIP)
    ├── Databases 2
    ├── Formal Languages and Compilers (WIP)
    ├── Foundations of Operation Research (WIP)
    ├── Hypermedia Applications (WIP)
    ├── Machine Learning (WIP)
    ├── Philosophical Issues of Computer Science (WIP)
    ├── Principles of Programming Languages(WIP)
    └── Software Engineering 2
````

## Generic course folder 

````
├── Course_Name.md // INDEX OF THE COURSE 
├── buildCOURSE.sh // script to build PDF file **ignore**
└── src 
    ├── 00.Header.md //necessary to build PDF **ignore**
    ├── ... .md //CHAPTERS OF THE COURSE
    ├── ... .md 
    ....
    └── images 
        ├── ... .png 
        ├── ... .jpg
        ....
````

## PDF of each course 

**TL;DR:** you can find the PDF file of each course in [realeses](https://github.com/martinopiaggi/polimi-notes/releases).

I consider the PDF files to be artifacts, and therefore I choosed to not include them in the repository itself but in the releases section.
I generate the PDFs using Pandoc after some relevant changes and then a Github Actions workflow uploads them in the "Releases" section of this repository.
<img width="1524" alt="Screenshot 2023-04-02 190129" src="https://user-images.githubusercontent.com/72280379/229372466-4f7d3ef4-c5f6-4cdf-af27-f5bcb494eb4f.png">

In particular `buildEveryPDFInMSC.sh` and `buildEveryPDFInBSC.sh` scripts generate all the PDFs of (respectively) the Master courses and the Bachelor courses.