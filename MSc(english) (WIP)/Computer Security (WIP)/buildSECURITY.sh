echo "Generating PDF for Computer Security"
echo $(pandoc --resource-path=src:src/images src/*.md -o Security.pdf -f markdown-implicit_figures)
