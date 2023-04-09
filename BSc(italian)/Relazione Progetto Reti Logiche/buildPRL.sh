echo "Generating PDF for Relazione Progetto Reti Logiche"
echo $(pandoc --resource-path=src:src/images src/*.md -o progetto_reti_logiche.pdf -f markdown-implicit_figures)
