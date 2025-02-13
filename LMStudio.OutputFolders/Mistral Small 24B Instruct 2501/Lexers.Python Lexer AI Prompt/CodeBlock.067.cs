using System;
using System.Collections.Generic;

public class CompoundStatement : Statement
{
    public List<Statement> Body { get; set; }

    public CompoundStatement( List<Statement> body )
    {
        this.Body = body ?? throw new ArgumentNullException(nameof(body));
    }
}